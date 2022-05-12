let tracks = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:39135/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TrackCreated", (user, message) => {
        getdata();
    });

    connection.on("TrackDeleted", (user, message) => {
        getdata();
        connection.on("TrackUpdated", (user, message) => {
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
    await fetch('http://localhost:39135/track')
        .then(x => x.json())
        .then(y => {
            tracks = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    tracks.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.trackid + "</td><td>"
        + t.nameplace + "</td><td>" +
        + t.length + "</td><td>"
        `<button type="button" onclick="Delete(${t.trackid})">Delete</button>` + `<button type="button" onclick="Update(${t.id})">Update</button>`
            + "</td></tr>";
    });
}

function Update(albumid) {
    let trackid = document.getElementById('Track_Id').value;
    let nameplace = document.getElementById('Name_Palce').value;
    let length = document.getElementById('Length_Track').value;
    fetch('http://localhost:39135/track', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { TrackId: trackid, NamePlace: nameplace, Length: length })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}


function Delete(albumid) {
    fetch('http://localhost:39135/track' + albumid, {
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
    let trackid = document.getElementById('Track_Id').value;
    let nameplace = document.getElementById('Name_Palce').value;
    let length = document.getElementById('Length_Track').value;

    fetch('http://localhost:39135/track', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { TrackId: trackid, NamePlace: nameplace, Length: length })
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