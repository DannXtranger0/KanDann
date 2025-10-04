import { useEffect, useRef, useState } from "react";
import { Link, Outlet } from "react-router-dom";
import LinkButton from "../components/LinkButton";
import "../styles/Layout.css"
import logo from "../assets/Kandann.svg";
import deskIcon from "../assets/desk.svg";
import bellIcon from "../assets/bell.svg";
import dashboardIcon from "../assets/chart-infographic.svg";
import menuIcon from "../assets/layout-sidebar.svg"
import { useMenuToggle } from "../hooks/useMenuToggle";
const API_URL = import.meta.env.VITE_API_URL;

function Layout() {

    const [isShowing, setIsShowing] = useState(false); 
    const menuRef = useRef(null);

    useMenuToggle(menuRef, ()=> setIsShowing(false));

    return (
        <div className="layout-container"  >
            <div className="menu-icon-container">
                <input type="checkbox" hidden  id="layout-menu" />
                <label className="layout-menu" htmlFor="layout-menu"  onClick={() => setIsShowing(!isShowing) }>
                    <img src={menuIcon} alt="" />
                </label>

            </div>
            
                <aside ref={menuRef} className="menu-aside-wrapper" style={isShowing? {translate:0} : {translate:"-150%"}}>
                    <nav className="nav-container">

                        <div className="logo-container">
                            <img src={logo} alt="" />
                        </div>

                        <div className="link-wrapper">
                            <LinkButton route={"/workplaces"} tag={"Workplaces"} imgUrl={deskIcon}></LinkButton>
                            <LinkButton route={"/dashboard"} tag={"Dashboard"} imgUrl={dashboardIcon}></LinkButton>
                        </div>

                    </nav>

                </aside>


            <main  className="board-wrapper"  >
                <Outlet/>
            </main>
        </div>
    );
}

export default Layout;