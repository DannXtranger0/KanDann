import React from 'react';
import {Routes, Route } from 'react-router-dom';
import Index from '../pages/Index';
// Import your page components here
// import HomePage from '../pages/HomePage';
// import AboutPage from '../pages/AboutPage';
// import NotFoundPage from '../pages/NotFoundPage';

const AppRoutes = () => (
    <Routes>
        {<Route path="/" element={<Index />} /> }
    </Routes>
);

export default AppRoutes;