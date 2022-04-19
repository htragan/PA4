const baseUrl = "https://localhost:7282/api/Songs"; 
var songList = [];
var mySong = {};

//console.log is your FRIEND

function handleOnLoad() 
{
    populateList();
}



function populateList() 
{
    const allSongsApiUrl = baseUrl;
    fetch(allSongsApiUrl).then(function(response) {
        return response.json();
    }).then(function(json) {
        songList = json;

    let html = `<select class = "listbox" id ="selectListBox" onClick = "handleOnChange()" name = "list_box" size=5 width="100%">`; //took out onclick
    json.forEach((song) => {
        html += `<option value = ${song.songID}> ${song.songTitle}</option>`;
    })
    html += "</select>";
    document.getElementById("listbox").innerHTML = html;
}).catch(function(error) {
    console.log(error);
});
}

function handleOnChange() {
    const selectedId = document.getElementById("selectListBox").value;
    console.log("made it to change", selectedId)
    songList.forEach((song) => 
    {
        if (song.songID == selectedId) {
            console.log("in the if statement");
            mySong = song;
            populateForm();
        }
    })
}

function populateForm() {
    document.getElementById("songTitle").value = mySong.songTitle;
    document.getElementById("songDeleted").value = mySong.deleted;
    document.getElementById("songFavorited").value = mySong.favorited;
}

function putBook(id) {
    
    const putSongApiUrl = baseUrl + "/" + songID;
    const sendSong = {
        songID: songID,
        title: document.getElementById("songTitle").value,
        favorited: document.getElementById("songFavorited").value,
        deleted: document.getElementById("songDeleted").value,
    }
    
    fetch(putSongApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type":'application/json',
        },
        body: JSON.stringify()
    })
    .then((response)=>{
        mySong = sendSong;
        populateList();
        populateForm();
    })
       
}