function loadRepos() {
    let xhr = new XMLHttpRequest();

    xhr.onreadystatechange = function() {
        if(this.status == 200 && this.readyState == 4) {
            document.getElementById('res').textContent = this.responseText;
        }
    }

    xhr.open("GET", "https://api.github.com/users/testnakov/repos", true);
    xhr.send();
}