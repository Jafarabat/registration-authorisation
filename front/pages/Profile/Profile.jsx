import React from "react";
import "./Profile.css";
import avatar from "../../image/avatar.jpg";

const Profile = () => {
  return (
    <div>
  <div className="main">
    <div className="content">
      <div className="avatar">
        <img className="avatar-picture" src={avatar} alt="avatar" />
      </div>
      <div className="info">
        <p>Username: Example Name</p>
        <p>Email: email@address.com</p>
      </div>
    </div>
  </div>
</div>
  );
};

export default Profile;
