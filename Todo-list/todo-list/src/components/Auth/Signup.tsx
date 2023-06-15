import { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import classes from "./signup.module.css";

//TODO Implement Formik

const Signup = () => {
  const [state, setState] = useState({});
  const [photo, setPhoto] = useState("");
  const [error, setError] = useState(false);
  const [emptyFields, setEmptyFields] = useState(false);
  const navigate = useNavigate();

  const handleState = (e: any) => {
    setState((prev) => {
      return { ...prev, [e.target.name]: e.target.value };
    });
  };

  const handleRegister = async (e: any) => {
    e.preventDefault();

    // how to check if ONLY ONE of the values of an object is empty
    if (Object.values(state).some((v) => v === "")) {
      setEmptyFields(true);
      setTimeout(() => {
        setEmptyFields(false);
      }, 2500);
    }

    //TODO implement Sign Up logic
  };

  return (
    <div className={classes.container}>
      <div className={classes.wrapper}>
        <h2>Sign Up</h2>
        <form onSubmit={handleRegister}>
          <input
            type="text"
            name="username"
            placeholder="Username..."
            onChange={handleState}
          />
          <input
            type="text"
            name="email"
            placeholder="Email..."
            onChange={handleState}
          />
          <label htmlFor="photo">Upload photo</label>
          <input
            style={{ display: "none" }}
            id="photo"
            type="file"
            //TODO fix the setPhoto logic
            onChange={(e) => setPhoto("")}
          />
          <input
            type="password"
            name="password"
            placeholder="Password..."
            onChange={handleState}
          />
          <button type="submit">Register</button>
          <p>
            Already have an account? <Link to="/signin">Login</Link>
          </p>
        </form>
        {error && (
          <div className={classes.error}>
            There was an error signing up! Try again.
          </div>
        )}
        {emptyFields && <div className={classes.error}>Fill all fields!</div>}
      </div>
    </div>
  );
};

export default Signup;
