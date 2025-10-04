import React from 'react';
import {Routes, Route,Navigate } from 'react-router-dom';
import Index from '../pages/Index';
import Layout from '../pages/Layout';
import NewUser from '../pages/NewUser';
import CreateBoard from '../pages/CreateBoard';
import Board from '../pages/Board';
// Import your page components here
// import HomePage from '../pages/HomePage';
// import AboutPage from '../pages/AboutPage';
// import NotFoundPage from '../pages/NotFoundPage';

const AppRoutes = () => (
    <Routes>
        <Route path="/" element={<Index />} />

        <Route path="/board" element={<Layout />}>
            {/* al ser rutas hijas, ya generan el board */}
            <Route path='create' element={<CreateBoard/>}/>
            <Route path=':id' element={<Board/>}/>
        </Route>

        <Route path='/new-user' element={<NewUser />} />
        <Route path='*' element={<Navigate to='/' replace />} />

    </Routes>
);

export default AppRoutes;