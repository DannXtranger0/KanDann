import "../styles/components/Column.css"
import Minus from "../assets/minus.svg"
import { useState } from "react";
function Column({name, isCreating,children,typeColumn}){


    return(
        <section className="column-wrapper">
            <div className="column-top">
                {isCreating ? 
                <div className="column-top-edit" >
                    <input type="text" defaultValue={name}   className="input-column"/>
                    <button className="column-btn-minus">
                        <img src={Minus} alt="" />
                    </button>
                </div>

                : <h3>{name}</h3>
                }
                
            </div>
            <div>
                {children}
            </div>
        </section>
    );
}
export default Column;