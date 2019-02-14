import React from 'react';
import ReactDOM from 'react-dom';
import './style/index.css';
import './style/app.css';
import * as serviceWorker from './serviceWorker';
import contactsJson from './data/contacts';

let currentIndex = 0;

const Contact = (props) => (
  <div className="contact" data-id={"id-" + props.index} onClick={
      () => {
          currentIndex = props.index;
          render();
      }
      }>
      <span className="avatar small">&#9787;</span>
      <span className="title">{props.firstName} {props.lastName}</span>
  </div>
);

const AllContacts = () => (
  <React.Fragment>
    {
      contactsJson.map((c, i) => {
        return <Contact firstName={c.firstName} lastName={c.lastName} index={i} key={i}/>
      })
    }
  </React.Fragment>
);

const Details = (props) => (
  <React.Fragment>
  <h1>Details</h1>
  <div className="content">
      <div className="info">
          <div className="col">
              <span className="avatar">&#9787;</span>
          </div>
          <div className="col">
              <span className="name">{contactsJson[props.index].firstName}</span>
              <span className="name">{contactsJson[props.index].lastName}</span>
          </div>
      </div>
      <div className="info">
          <span className="info-line">&phone; {contactsJson[props.index].phone}</span>
          <span className="info-line">&#9993; {contactsJson[props.index].email}</span>
      </div>
  </div>
  </React.Fragment>
);

const Header = () => <header>&#9993; Contact Book</header>;
const Footer = () => <footer>Contact Book SPA &copy; 2017</footer>;

const Book = () => (
  <div id="book">
    <div id="list">
        <h1>Contacts</h1>
        <div className="content">
          <AllContacts />
        </div>
    </div>
    <div id="details">
        <Details index={currentIndex} />
    </div>
  </div>
);

const App = () => (
    <React.Fragment>
    <Header />
    <Book />
    <Footer />
    </React.Fragment>
  );

function render() {
    ReactDOM.render(<App />, document.getElementById('root'));
}

render();

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
