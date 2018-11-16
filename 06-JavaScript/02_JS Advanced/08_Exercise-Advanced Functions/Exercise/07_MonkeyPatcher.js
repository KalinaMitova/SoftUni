function solution(args) {
    if(!this.hasOwnProperty("upvote") || 
        !this.hasOwnProperty("downvote") || 
        !this.hasOwnProperty("score")) {
            attach.call(this);
    }

    let result = this[args]();
    if(result) {
        return result;
    }

    function attach() {
        this.upvote = function() {
            this.upvotes += 1;
        };
        this.downvote = function() {
            this.downvotes += 1;
        };
        this.score = function() {
            let totalVotes = this.upvotes + this.downvotes;
            let upvoteScore = this.upvotes;
            let downvoteScore = this.downvotes;
    
            if(totalVotes > 50) {
                let bigger = Math.max(this.upvotes, this.downvotes);
                let numberToAdd = Math.ceil(bigger * 0.25);
                upvoteScore += numberToAdd;
                downvoteScore += numberToAdd;
            }
    
            let balance = upvoteScore - downvoteScore;
    
            let upvoteMajority = this.upvotes / totalVotes * 100;
    
            let rating;
            if(upvoteMajority > 66) {
                rating = "hot";
            } else if(totalVotes > 100 && balance >= 0) {
                rating = "controversial";
            } 
            
            if (balance < 0) {
                rating = "unpopular";
            }
            if(totalVotes < 10 || !rating) {
                rating = "new";
            }
    
            return [upvoteScore, downvoteScore, balance, rating];
        }; 
    }   
}

let post = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 0
};

solution.call(post, 'upvote');
let score = solution.call(post, 'score');
console.log(score);