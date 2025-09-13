import React from 'react';
import {Routes, Route } from 'react-router-dom';
import Login from '../pages/Login';
// Import your page components here
// import HomePage from '../pages/HomePage';
// import AboutPage from '../pages/AboutPage';
// import NotFoundPage from '../pages/NotFoundPage';

const AppRoutes = () => (
    <Routes>
        {<Route path="/" element={ <Login/>} /> }
    </Routes>
);

export default AppRoutes;