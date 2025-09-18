import { useEffect, useState } from "react";
function Login() {
    const [user, setUser] = useState(null);
    const [loading, setLoading] = useState(true);
    const [err, setErr] = useState(null);

    const API_URL = import.meta.env.VITE_API_URL;

    async function fetchUser() {
        setLoading(true);
        setErr(null);
        try {
            const res = await fetch(API_URL+'/auth/user', {
                credentials: 'include'
            });
            if (res.status === 401) {
                setUser(null);
            } else if (!res.ok) {
                const t = await res.text();
                throw new Error(t || 'Error fetching user');
            } else {
                const data = await res.json();
                console.log(data)
                setUser(data);
            }
        } catch (e) {
            setErr(e.message);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        fetchUser();
    }, []);

    return (
        <div style={{ padding: 24, fontFamily: 'system-ui, sans-serif' }}>
            <h1>KanDann</h1>

            {loading && <p>Comprobando sesión...</p>}

            {!loading && !user && (
                <>
                    <p>No autenticado.</p>
                    <a href={API_URL + "/auth/signin"}>Iniciar sesión con Google</a>
                    {err && <pre style={{ color: 'crimson' }}>{err}</pre>}
                </>
            )}

            {!loading && user && (
                <>
                    <p>Autenticado como:  <b>{user.claims.find(c=>c.type==="name").value ?? '—'}</b></p>
                    <p>Correo:  <b>{user.claims.find(c => c.type === "email").value ?? '—'}</b></p>

                    <div>
                        <img style={{ textAlign: "center" }} src={user.claims.find(c => c.type === "picture").value}></img>

                    </div>

                    <a href={API_URL + "/auth/signout"}>Cerrar sesión</a>
                </>
            )}
        </div>
    );
}

export default Login;