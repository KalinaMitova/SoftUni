class BookCollection {
    constructor(shelfGenre, room, shelfCapacity) {
        this.room = room;
        this.shelfGenre = shelfGenre;
        this.shelf = [];
        this.shelfCapacity = +shelfCapacity;
    }

    get room() {
        return this._room;
    }

    set room(val) {
        switch (val) {
            case 'livingRoom':
            case 'bedRoom':
            case 'closet':
                this._room = val;
                break;        
            default:
                throw `Cannot have book shelf in ${val}`;
        }
    }

    get shelfCondition() {
        return Math.max(0, this.shelfCapacity - this.shelf.length);
    }

    addBook(bookName, bookAuthor, genre) {
        if(this.shelfCondition === 0) {
            this.shelf.shift();
        }

        let book = { bookName, bookAuthor, genre };

        this.shelf.push(book);

        this.shelf = this.shelf.sort((a, b) => a.bookAuthor.localeCompare(b.bookAuthor));

        return this;
    }

    throwAwayBook(bookName) {
        this.shelf = this.shelf.filter((book) => {
            return book.bookName !== bookName;
        });
    }

    showBooks(genre) {
        let output = `Results for search "${genre}":`;
        let booksByGenre = this.shelf.filter((book) => {
            return book.genre === genre;
        });

        booksByGenre.forEach((book) => {
            output += `\n\uD83D\uDCD6 ${book.bookAuthor} - "${book.bookName}"`;
        });

        return output;
    }
    
    toString() {
        if(this.shelf.length === 0) {
            return "It's an empty shelf";
        }

        let output = `"${this.shelfGenre}" shelf in ${this.room} contains:`;
        this.shelf.forEach((book) => {
            output += `\n\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}`;
        })

        return output;
    }
}