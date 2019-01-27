let assert = require('chai').assert;
let expect = require('chai').expect;
let SoftUniFy = require('../app');

describe("SoftUniFy tests", function() {
    let softUniFy;

    this.beforeEach(function() {
        softUniFy = new SoftUniFy();
    });

    describe("constructor", function() {

        it("should have allSongs property", function(){    
            expect(softUniFy).to.have.property("allSongs");
            expect(softUniFy.allSongs).to.be.empty;
        });
    });

    describe("downloadSong(artist, song, lyrics) ", function() {

        it("should downloadSong add song", function() {
            // artist: {rate: 0, votes: 0, songs: []} 
            let artist = "someArtist";
            let song1 = "songggg";
            let song2 = "so1adg3ngggg";
            let lyrics1 = 'asdasdasd';
            let lyrics2 = 'asda315sdasd';

            let returnedValue = softUniFy.downloadSong(artist, song1, lyrics1);
            softUniFy.downloadSong(artist, song2, lyrics2);

            expect(softUniFy.allSongs[artist]).not.to.be.undefined;
            expect(softUniFy.allSongs[artist]).to.have.property("rate");
            expect(softUniFy.allSongs[artist]).to.have.property("votes");
            expect(softUniFy.allSongs[artist]).to.have.property("songs");
            expect(softUniFy.allSongs[artist].rate).to.be.equal(0);
            expect(softUniFy.allSongs[artist].votes).to.be.equal(0);
            expect(softUniFy.allSongs[artist].songs).not.to.be.empty;
            expect(softUniFy.allSongs[artist].songs).to.have.length(2);
            expect(softUniFy.allSongs[artist].songs[0]).to.be.equal(`${song1} - ${lyrics1}`);
            expect(softUniFy.allSongs[artist].songs[1]).to.be.equal(`${song2} - ${lyrics2}`);
            expect(returnedValue).to.be.equal(softUniFy);
        });        
    });

    describe("playSong(song) ", function() {

        it("should return list of finded songs", function() {
            softUniFy.downloadSong("Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("Another Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("asdasd", "asdasd", "dsadsa");

            let result = softUniFy.playSong("josh song1");
            let expected = "Josh:\njosh song1 - josh lyrics\nAnother Josh:\njosh song1 - josh lyrics\n"

            assert.equal(result, expected);
        });

        it("should return message for no songs", function() {
            let result = softUniFy.playSong("asd");
            let expected = `You have not downloaded a asd song yet. Use SoftUniFy's function downloadSong() to change that!`;
            assert.equal(result, expected);
        });

        it("should return message for not finded songs", function() {
            softUniFy.downloadSong("Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("Another Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("asdasd", "asdasd", "dsadsa");

            let result = softUniFy.playSong("invalidSongName");
            let expected = `You have not downloaded a invalidSongName song yet. Use SoftUniFy's function downloadSong() to change that!`;
            assert.equal(result, expected);
        });
    });

    describe("songsList", function() {
        
        it("should return message for empty list", function() {

            let result = softUniFy.songsList;
            let expected = "Your song list is empty";

            assert.equal(result, expected);
        });

        it("should return songs", function() {            
            softUniFy.downloadSong("Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("Another Josh", "josh song1", "josh lyrics");
            softUniFy.downloadSong("asdasd", "asdasd", "dsadsa");

            let result = softUniFy.songsList;
            let expected = "josh song1 - josh lyrics\njosh song1 - josh lyrics\nasdasd - dsadsa";

            assert.equal(result, expected);
        });
    });

    describe("rateArtist()", function() {
        
        it("should return message", function() {
            let result = softUniFy.rateArtist("artist");
            let expected = `The artist is not on your artist list.`;

            assert.equal(result, expected);
        });
        
        it("should return zero", function() {
            softUniFy.downloadSong("Josh", "josh song", "josh lyrics");
            
            let result = softUniFy.rateArtist("Josh");

            assert.equal(result, 0);
        });
        
        it("should return votes", function() {
            softUniFy.downloadSong("Josh", "josh song", "josh lyrics");

            softUniFy.rateArtist("Josh", 5);
            softUniFy.rateArtist("Josh", 8);
            let result = softUniFy.rateArtist("Josh", 10);

            let expected = 7.67;

            assert.equal(result, expected);
        });
    });
 }); 

 