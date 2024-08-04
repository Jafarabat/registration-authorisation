import axios from "axios";

export const registration = async (userRegInfo) => {
  return await axios.post("http://localhost:5274/User/SignUp", userRegInfo);
};

export const login = async (userLoginInfo) => {
    return await axios.post("http://localhost:5274/User/SignIn", userLoginInfo);
};
