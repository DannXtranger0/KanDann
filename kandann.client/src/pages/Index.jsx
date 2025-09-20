import { useEffect, useState } from "react";
import '../styles/Index.css'
import logo from "../assets/Logo.png";
import gmail from "../assets/Gmail.png";
import GifPlaceHolder from "../assets/GifPlaceHolder.png"
import CustomButton from "../components/CustomButton";

function Index() {
    //const [user, setUser] = useState(null);
    //const [loading, setLoading] = useState(true);
    //const [err, setErr] = useState(null);

    //const API_URL = import.meta.env.VITE_API_URL;

    //async function fetchUser() {
    //    setLoading(true);
    //    setErr(null);
    //    try {
    //        const res = await fetch(API_URL+'/auth/user', {
    //            credentials: 'include'
    //        });
    //        if (res.status === 401) {
    //            setUser(null);
    //        } else if (!res.ok) {
    //            const t = await res.text();
    //            throw new Error(t || 'Error fetching user');
    //        } else {
    //            const data = await res.json();
    //            console.log(data)
    //            setUser(data);
    //        }
    //    } catch (e) {
    //        setErr(e.message);
    //    } finally {
    //        setLoading(false);
    //    }
    //}

    //useEffect(() => {
    //    fetchUser();
    //}, []);


    return (
        <main className="index-wrapper">
            <header className="header">
                <img src={logo}></img>
                <CustomButton >
                    <img src={gmail}></img>
                    Start
                </CustomButton>
            </header>


            <section className="description-container">
                <h1>Get Organized With KanDann</h1>

                <img className="site-gif" src={GifPlaceHolder}></img>
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
                <CustomButton >
                    <img src={gmail}></img>
                    Start
                </CustomButton>
            </section>
        </main>
    );

    //return (
        //<div style={{ padding: 24, fontFamily: 'system-ui, sans-serif' }}>
        //    <h1>KanDann</h1>

        //    {loading && <p>Comprobando sesión...</p>}

        //    {!loading && !user && (
        //        <>
        //            <p>No autenticado.</p>
        //            <a href={API_URL + "/auth/signin"}>Iniciar sesión con Google</a>
        //            {err && <pre style={{ color: 'crimson' }}>{err}</pre>}
        //        </>
        //    )}

        //    {!loading && user && (
        //        <>
        //            <p>Autenticado como:  <b>{user.claims.find(c=>c.type==="name").value ?? '—'}</b></p>
        //            <p>Correo:  <b>{user.claims.find(c => c.type === "email").value ?? '—'}</b></p>

        //            <div>
        //                <img style={{ textAlign: "center" }} src={user.claims.find(c => c.type === "picture").value}></img>

        //            </div>

        //            <a href={API_URL + "/auth/signout"}>Cerrar sesión</a>
        //        </>
        //    )}
        //</div>
    //);
}

export default Index;