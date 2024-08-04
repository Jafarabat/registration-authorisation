import React, { useState } from "react";
import "./Registration.css";
import { Link } from "react-router-dom";
import { registration } from "../../services";

const Registration = () => {
  const [userRegInfo, setUserRegInfo] = useState("");
  const [errorMessage, setErrorMessage] = useState("");

  const onRegister = async (e) => {
    e.preventDefault();
    if (userRegInfo.password !== userRegInfo.passwordConfirmation) {
      setErrorMessage("Пароли не совпадают!");
      return;
    }
    try {
      const response = await registration(userRegInfo);
      setErrorMessage("");
      setUserRegInfo("");
    } catch (e) {
      const errors = e.response.data.errors;
      const errorMessages = Object.values(errors).flat();
      setErrorMessage(errorMessages);
    }
  };

  return (
    <div className="register">
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
        <p className="register-header">Register an account</p>
        <Link className="sign-button" to="/login">
          or Log in to your account
        </Link>
      </div>

      <form action="" onSubmit={onRegister}>
        <div className="register-form">
          <label>Username</label>
          <input
            minLength={4}
            maxLength={16}
            required
            type="text"
            placeholder="Username"
            value={userRegInfo?.username ?? ""}
            onChange={(e) =>
              setUserRegInfo({ ...userRegInfo, username: e.target.value })
            }
          />
        </div>

        <div className="register-form">
          <label>Email Address</label>
          <input
            required
            //type="email"
            placeholder="email@address.com"
            value={userRegInfo?.email ?? ""}
            onChange={(e) =>
              setUserRegInfo({ ...userRegInfo, email: e.target.value })
            }
          />
        </div>

        <div className="register-form">
          <label>Password</label>
          <input
            required
            minLength={8}
            type="password"
            placeholder="Password"
            value={userRegInfo?.password ?? ""}
            onChange={(e) =>
              setUserRegInfo({ ...userRegInfo, password: e.target.value })
            }
          />
        </div>

        <div className="register-form">
          <label>Confirm password</label>
          <input
            required
            //minLength={8}
            type="password"
            placeholder="Password confirmation"
            value={userRegInfo?.passwordConfirmation ?? ""}
            onChange={(e) =>
              setUserRegInfo({
                ...userRegInfo,
                passwordConfirmation: e.target.value,
              })
            }
          />
        </div>

        {/* <Link className='register-bttn' to='/profile'>Register</Link> */}
        <button className="register-bttn">Register</button>
      </form>
    </div>
  );
};

export default Registration;
