import Plus from "../assets/plus.svg"
import "../styles/CreateBoard.css"
import Button from "../components/Button";
import BoardLayout from "../components/boardLayout";
import Column from "../components/Column";
import { useSearchParams } from "react-router-dom";
import { useState } from "react";
function CreateBoard(){
    
    return(
        <BoardLayout>
            <div className="board-container">
                <section className="top-board-wrapper">
                    <div className="top-board">
                        <Button size={"tn"}>Save Board</Button>
                        <input type="text" placeholder="Board Name" />
                        <Button size={"tn"} icon={Plus}>New Column</Button>
                    </div>

                </section>
                <section className="content-board-wrapper">
                    <div className="content-board">
                        <Column  name={"ToDo"} isCreating={true}>
                        </Column>

                        <Column  name={"Doing"} isCreating={true}>
                        </Column>

                        <Column  name={"Done"} isCreating={true}>
                        </Column>

                       
                    </div>
                   
                </section>
            </div>
        </BoardLayout>
    );
}
export default CreateBoard;