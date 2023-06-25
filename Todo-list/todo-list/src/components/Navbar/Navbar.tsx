import { useState } from "react";
import classes from "./navbar.module.css";
import { Link, useNavigate } from "react-router-dom";
import { Button } from "react-bootstrap";

const Navbar = () => {
  const [state, setState] = useState({});
  const [isScrolled, setIsScrolled] = useState(false);
  const [showForm, setShowForm] = useState(false);
  const [error, setError] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const navigate = useNavigate();

  const user = JSON.parse(localStorage.getItem("user") || "");

  window.onscroll = () => {
    setIsScrolled(window.pageYOffset === 0 ? false : true);
    return () => (window.onscroll = null);
  };

  const scrollToTop = () => {
    window.scrollTo(0, 0);
  };

  const handleLogout = () => {
    //TODO implement logout func
    navigate("/signin");
  };

  const handleCloseForm = () => {
    setShowForm(false);
    setState({});
  };

  return (
    <div className={`${classes.container} ${isScrolled && classes.scrolled}`}>
      <div className={classes.wrapper}>
        <Link to="/" onClick={scrollToTop} className={classes.left}>
          Todo list
        </Link>
        <ul className={classes.center}>
          <li onClick={scrollToTop} className={classes.listItem}>
            Home
          </li>
          <li className={classes.listItem}>About</li>
          <li className={classes.listItem}>Featured</li>
          <li className={classes.listItem}>Contacts</li>
        </ul>
        <div className={classes.right}>
          {!user ? (
            <>
              <Link to="/signup">Sign up</Link>
              <Link to="/signin">Sign in</Link>
            </>
          ) : (
            <>
              <span
                className={classes.username}
                onClick={() => setShowModal((prev) => !prev)}
              >
                Hello {user.username}!
              </span>
              {showModal && (
                <div className={classes.userModal}>
                  <span className={classes.logoutBtn} onClick={handleLogout}>
                    Logout
                  </span>
                  <Link
                    to={`/my-profile`}
                    onClick={() => setShowModal((prev) => !prev)}
                    className={classes.myProfile}
                  >
                    My Profile
                  </Link>
                  <Link
                    onClick={() => setShowForm(true)}
                    className={classes.list}
                    to={"/add-new-task"}
                  >
                    Add a task
                  </Link>
                </div>
              )}
            </>
          )}
        </div>
      </div>

      {
        <div className={classes.mobileNav}>
          <div className={classes.navigation}>
            <Link to="/" onClick={scrollToTop} className={classes.left}>
              Todo list
            </Link>
            <ul className={classes.center}>
              <li onClick={scrollToTop} className={classes.listItem}>
                Home
              </li>
              <li className={classes.listItem}>About</li>
              <li className={classes.listItem}>Featured</li>
              <li className={classes.listItem}>Contacts</li>
            </ul>
            <div className={classes.right}>
              {!user ? (
                <>
                  <Link to="/signup">Sign up</Link>
                  <Link to="/signin">Sign in</Link>
                </>
              ) : (
                <>
                  <span>Hello {user.username}!</span>
                  <span className={classes.logoutBtn} onClick={handleLogout}>
                    Logout
                  </span>
                  <Link
                    onClick={() => setShowForm(true)}
                    className={classes.list}
                    to={""}
                  >
                    My tasks
                  </Link>
                </>
              )}
            </div>
            {showForm && (
              <div
                className={classes.listPropertyForm}
                onClick={handleCloseForm}
              ></div>
            )}
          </div>
        </div>
      }

      {/* error */}
      {error && (
        <div className={classes.error}>
          <span>All fields must be filled!</span>
        </div>
      )}
    </div>
  );
};

export default Navbar;
