import TasksList from "./components/Task/TasksList";
import Navbar from "./components/Navbar/Navbar";

import "./App.css";
import { Navigate, Route, Routes, useLocation } from "react-router-dom";
import Signup from "./components/Auth/Signin";
import Signin from "./components/Auth/Signin";
import { useEffect } from "react";

function App() {
  const user = JSON.parse(localStorage.getItem("user") || "");
  const url = useLocation().pathname;

  useEffect(() => {
    url && window.scrollTo(0, 0);
  }, [url]);

  return (
    <div className="App">
      <Routes>
        <Route
          path="/"
          element={
            <>
              <Navbar />
              <TasksList />
            </>
          }
        />

        <Route
          path="/signup"
          element={!user ? <Signup /> : <Navigate to="/" />}
        />
        <Route
          path="/signin"
          element={!user ? <Signin /> : <Navigate to="/" />}
        />
      </Routes>
    </div>
  );
}

export default App;
