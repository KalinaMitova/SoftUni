function loadCommits() {
    let username = $('#username');
    let repo = $('#repo');

    let url = `https://api.github.com/repos/${username.val()}/${repo.val()}/commits`;

    $.ajax({
        method: "GET",
        url: url,
        success: function(data) {
            let commits = $('#commits');
            commits.html("");

            data.forEach((item) => {
                commits.append($('<li>').text(`${item.commit.author.name}: ${item.commit.message}`));
            });
        },
        error: function(error) {
            $('#commits')
                .html("")
                .append($('<li>')
                .text(`Error: ${error.status} (${error.statusText})`));            
        }
    });
}