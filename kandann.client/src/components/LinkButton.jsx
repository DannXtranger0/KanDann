import { NavLink } from "react-router-dom";

import "../styles/components/LinkButton.css"

function LinkButton({tag,route,imgUrl}){

    return(
            <NavLink className="link-container" to={route}>
                <img src={imgUrl} alt="" />
                <span>{tag}</span>
            </NavLink>

    );
}

export default LinkButton