import { useState } from "react";
import classes from "./signin.module.css";
import { Link } from "react-router-dom";

//TODO Implement Formik

const Signup = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(false);
  const [emptyFields, setEmptyFields] = useState(false);

  const handleLogin = async (e: any) => {
    e.preventDefault();

    if (email === "" || password === "") {
      setEmptyFields(true);
      setTimeout(() => {
        setEmptyFields(false);
      }, 2500);
    }

    //TODO Set Login Logic
  };

  return (
    <div className={classes.container}>
      <div className={classes.wrapper}>
        <h2>Sign in</h2>
        <form onSubmit={handleLogin}>
          <input
            type="email"
            placeholder="Email..."
            onChange={(e) => setEmail(e.target.value)}
          />
          <input
            type="password"
            placeholder="Password..."
            onChange={(e) => setPassword(e.target.value)}
          />
          <button type="submit">Sign in</button>
          <p>
            Already have an account? <Link to="/signup">Register</Link>
          </p>
        </form>
        {error && (
          <div className={classes.error}>
            There was an error signing in! Wrong credentials or server error
          </div>
        )}
        {emptyFields && <div className={classes.error}>Fill all fields!</div>}
      </div>
    </div>
  );
};

export default Signup;
