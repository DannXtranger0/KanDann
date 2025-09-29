import React from 'react';
import {Routes, Route,Navigate } from 'react-router-dom';
import Index from '../pages/Index';
import Board from '../pages/Board';
import NewUser from '../pages/NewUser';
// Import your page components here
// import HomePage from '../pages/HomePage';
// import AboutPage from '../pages/AboutPage';
// import NotFoundPage from '../pages/NotFoundPage';

const AppRoutes = () => (
    <Routes>
        {<Route path="/" element={<Index />} />}
        {<Route path="/board" element={<Board />} />}
        {<Route path='/new-user' element={<NewUser />} />}
        <Route path='*' element={<Navigate to='/' replace />} />

    </Routes>
);

export default AppRoutes;