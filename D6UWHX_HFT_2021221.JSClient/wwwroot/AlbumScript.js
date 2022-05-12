let albums = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:39135/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AlbumCreated", (user, message) => {
        getdata();
    });

    connection.on("AlbumDeleted", (user, message) => {
        getdata();
        connection.on("AlbumUpdated", (user, message) => {
            getdata();
        });

        connection.onclose(async () => {
            await start();
        });
        start();

    }
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:39135/album')
        .then(x => x.json())
        .then(y => {
            tracks = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    brands.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.albumid + "</td><td>"
        + t.titel + "</td><td>" +
        `<button type="button" onclick="Delete(${t.albumid})">Delete</button>` + `<button type="button" onclick="Update(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Update(albumid) {
    let albumid = document.getElementById('Album_ID').value;
    let titel = document.getElementById('Album_Titel').value;
    fetch('http://localhost:39135/album', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { AlbumID: albumid, Titel: titel })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function Delete(albumid) {
    fetch('http://localhost:39135/album' + albumid, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify({ AlbumID: albumid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function create() {
    let albumid = document.getElementById('Album_ID').value;
    let titel = document.getElementById('Album_Titel').value;

    fetch('http://localhost:39135/album', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { AlbumID: albumid, Titel: titel })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}

function ToStart() {
    location.replace("Page.html")
}