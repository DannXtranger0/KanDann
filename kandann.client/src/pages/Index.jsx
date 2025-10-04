import { useEffect, useState } from "react";
import '../styles/Index.css'
import logo from "../assets/Kandann.svg";
import mockupMobile from "../assets/mockupMobile.png"
import gmail from "../assets/Gmail.png";
import Button from "../components/Button";

function Index() {

    const handleLogin= ()=>{
        const API_URL = import.meta.env.VITE_API_URL;

        window.location.href = API_URL + "auth/signin";
    }

    return (
        <main className="index-wrapper">
            <header className="header">
                <img src={logo}></img>
                <div className="separator"></div>
            </header>


            <section className="description-container">
                <h1>Get Organized With KanDann</h1>
                <picture className="img-container"> 
                    <source srcSet={mockupMobile} media="(min-width: 350px)" />
                    <img src={mockupMobile} alt="Mockup en mobile" />

                    {/* todo añadir picture-img de la vista en desktop*/}
                </picture>
                <p>KanDann lets you organize all your projects using the Kanban methodology.
                    You can create as many workspaces as you want for your personal or team projects!</p>
            </section>

            <section className="adventages-container">
                <h1>Advantages of KanDann</h1>
                <ul>
                    <li>Different workspaces where you can create multiple boards.</li>
                    <li>Attach files to your tasks, such as images, PDFs, etc.</li>
                    <li>You can comment and receive feedback from your team on each task.</li>
                    <li>Free!</li>
                </ul>

                <p>Sign up with your Google account to use it for free!</p>
                <Button onClick={handleLogin} icon={gmail} >
                    Start
                </Button>
            </section>
        </main>
    );

    //return (
        //<div style={{ padding: 24, fontFamily: 'system-ui, sans-serif' }}>
        //    <h1>KanDann</h1>

        //    {loading && <p>Comprobando sesi�n...</p>}

        //    {!loading && !user && (
        //        <>
        //            <p>No autenticado.</p>
        //            <a href={API_URL + "/auth/signin"}>Iniciar sesi�n con Google</a>
        //            {err && <pre style={{ color: 'crimson' }}>{err}</pre>}
        //        </>
        //    )}

        //    {!loading && user && (
        //        <>
        //            <p>Autenticado como:  <b>{user.claims.find(c=>c.type==="name").value ?? '�'}</b></p>
        //            <p>Correo:  <b>{user.claims.find(c => c.type === "email").value ?? '�'}</b></p>

        //            <div>
        //                <img style={{ textAlign: "center" }} src={user.claims.find(c => c.type === "picture").value}></img>

        //            </div>

        //            <a href={API_URL + "/auth/signout"}>Cerrar sesi�n</a>
        //        </>
        //    )}
        //</div>
    //);
}

export default Index;