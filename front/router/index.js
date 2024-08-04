import Login from "../pages/Login/Login";
import Profile from "../pages/Profile/Profile";
import Registration from "../pages/Registration/Registration";

export const publicRoutes=[
    {path: '/login', component: Login, exact: true},
    {path: '/registration', component: Registration, exact: true},
    {path: '/profile', component: Profile, exact: true}
]

