import React from "react";
import { Route, Routes } from "react-router-dom";
import { publicRoutes } from "../router";
import Login from "../pages/Login/Login";
const AppRouter = () => {
  return (
    <div>
      <Routes>
        {publicRoutes.map((route) => (
          <Route
            Component={route.component}
            path={route.path}
            exact={route.exact}
            key={route.path}
          />
        ))}
        <Route path="*" element={<Login/>} />
      </Routes>
    </div>
  );
};

export default AppRouter;
