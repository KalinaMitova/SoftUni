function attachEvents() {
    $('#btnLoadPosts').on('click', loadPosts);
    $('#btnViewPost').on('click', viewPost);

    function viewPost() {
        let posts = $('#posts');
        let url = `https://baas.kinvey.com/appdata/kid_BJwfwCiA7/posts/${posts.val()}`;

        $.ajax({
            method: 'GET',
            url: url,
            headers: {
                authorization: `Basic ${btoa('peter:123456')}`
            }
        })
            .then(function(data) {
                let commentsUrl = `https://baas.kinvey.com/appdata/kid_BJwfwCiA7/comments/?query={"post_id":"${posts.val()}"}`;
                let postTitle = $('#post-title');
                let postBody = $('#post-body');
                
                postTitle.empty();
                postBody.empty();

                postTitle.text(data.title);
                postBody.text(data.body);

                $.ajax({
                    method: 'GET',
                    url: commentsUrl,
                    headers: {
                        authorization: `Basic ${btoa('peter:123456')}`
                    }
                })
                    .then(function(data) {
                        let postComments = $('#post-comments');
                        postComments.empty();

                        data
                            .forEach((comment) => {
                                postComments
                                    .append($('<li>')
                                        .text(comment.text));
                            });
                    });
            });
    }

    function loadPosts() {
        let url = `https://baas.kinvey.com/appdata/kid_BJwfwCiA7/posts/`;

        $.ajax({
            method: 'GET',
            url: url,
            headers: {
                authorization: `Basic ${btoa('peter:123456')}`
            }
        })
            .then(function(data) {
                let posts = $('#posts');
                posts.empty();

                data.forEach((post) => {
                    posts.append($('<option>')
                        .val(post._id)
                        .text(post.title))
                });
            });
    }
}