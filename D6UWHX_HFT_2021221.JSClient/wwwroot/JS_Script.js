let Tracks = [];
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
    });

    connection.onclose(async () => {
        await start();
    });
    start();


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
    await fetch('http://localhost:39135/Track')
        .then(x => x.json())
        .then(y => {
            Tracks = y;
            display();
        });
}

function display() {
    document.getElementById('result').innerHTML = "";
    Tracks.forEach(t => {
        document.getElementById('TableResult').innerHTML +=
            "<tr><td>" + t.TrackId + "</td><td>"
            + t.NamePlace + "</td><td>" +
            `<button type="button" onclick="remove(${t.Id})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:39135/Track/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('trackname').value;
    fetch('http://localhost:39135/Track', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { carName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}