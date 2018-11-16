function solve() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);

            this.likes = +likes;
            this.dislikes = +dislikes;
            this.comments = [];
        }

        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let output = super.toString();
            output += `\nRating: ${(this.likes - this.dislikes)}`;

            if(this.comments.length) {
                output += '\nComments:\n';

                this.comments.forEach((comment, index) => {
                    output += ` * ${comment}`;
    
                    if(index !== this.comments.length - 1) {
                        output += '\n';
                    }
                });
            }
            

            return output;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);

            this.views = +views;
        }

        view() {
            this.views += 1;

            return this;
        }

        toString() {
            let output = super.toString();

            output += `\nViews: ${this.views}`;

            return output;
        }
    }

    return {Post, SocialMediaPost, BlogPost};
}

let result = solve();

let scm = new result.SocialMediaPost("TestTitle", "TestContent", 25, 30);

scm.addComment("1");
scm.addComment("2");
scm.addComment("3");

console.log(scm.toString());
