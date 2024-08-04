import React, { useState } from "react";
import "./Login.css";
import { Link } from "react-router-dom";
import { login } from "../../services";

const Login = () => {
  const [userLoginInfo, setUserLoginInfo] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const onLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await login(userLoginInfo);
      setErrorMessage("");
      setUserLoginInfo("");
    } catch (e) {
      const errors = e.response.data.errors;
      const errorMessages = Object.values(errors).flat();
      setErrorMessage(errorMessages);
    }
  };

  return (
    <div className="login">
      {errorMessage.length > 0 && (
        <div className="error-notify">
          {errorMessage.map((msg, index) => (
            <span key={index} className="error-message">
              {msg}
            </span>
          ))}
        </div>
      )}
      <div className="welcome-title">
        <p className="login-header">Log into Something</p>
        <Link className="create-button" to="/registration">
          or Create Account
        </Link>
      </div>
      <form action="" onSubmit={onLogin}>
        <div className="login-form">
          <label>Email Address</label>
          <input
            required
            type="email"
            placeholder="email@address.com"
            value={userLoginInfo?.email ?? ""}
            onChange={(e) =>
              setUserLoginInfo({ ...userLoginInfo, email: e.target.value })
            }
          />
        </div>

        <div className="login-form">
          <label>Password</label>
          <input
            required
            minLength={8}
            type="password"
            placeholder="Password"
            value={userLoginInfo?.password ?? ""}
            onChange={(e) =>
              setUserLoginInfo({ ...userLoginInfo, password: e.target.value })
            }
          />
        </div>
        <button className="login-bttn" type="submit">
          {/* <Link className="login-bttn" to="/profile">
            Log in
          </Link> */}
          Log in
        </button>
      </form>
    </div>
  );
};

export default Login;
