let artists = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:39135/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ArtistCreated", (user, message) => {
        getdata();
    });

    connection.on("ArtistDeleted", (user, message) => {
        getdata();
        connection.on("ArtistUpdated", (user, message) => {
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
        await fetch('http://localhost:39135/artist')
            .then(x => x.json())
            .then(y => {
                artists = y;
                display();
            });
    }

    function display() {
        document.getElementById('resultarea').innerHTML = "";
        artists.forEach(t => {
            document.getElementById('resultarea').innerHTML +=
                "<tr><td>" + t.artistid + "</td><td>"
            + t.name + "</td><td>" + t.age + "</td><td>" +
            `<button type="button" onclick="Delete(${t.artistid})">Delete</button>` + `<button type="button" onclick="Update(${t.id})">Update</button>`
                + "</td></tr>";
        });
    }

    function Update(id) {
        let Name = document.getElementById('Artist_Name').value;
        let Age = document.getElementById('Artist_Age').value;
        fetch('http://localhost:39135/artist', {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(
                { ArtistId: artistid, Name: name, Age: age })
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => { console.error('Error:', error); });
    }


    function Delete(id) {
        fetch('http://localhost:39135/artist' + id, {
            method: 'DELETE',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify({ Id: id })
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => { console.error('Error:', error); });
    }

    function create() {
        let Name = document.getElementById('Artist_Name').value;
        let Age = document.getElementById('Artist_Age').value;

        fetch('http://localhost:39135/artist', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', },
            body: JSON.stringify(
                { ArtistId: artistid, Name: name, Age: age })
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