import { useEffect, useState } from "react";
import React from "react";
import { getData } from "../utils/getData";
import { useNavigate } from "react-router-dom";
import "../styles/NewUser.css";
import { Step1, Step2, Step3 } from "../components/NewUserForms";
import Button from "../components/Button";

const API_URL = import.meta.env.VITE_API_URL;

const steps = [<Step1 />, <Step2 />, <Step3/>];

function NewUser() {
  const navigate = useNavigate();
  const [step, setStep] = useState(0);
  const [formData, setFormData] = useState({
    workplace: "",
  });

  const next = () => setStep(s => s + 1);

  const handleSendForm = async() =>{
    await getData(`${API_URL}Workplace`,{
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json"},
      body: JSON.stringify({workplace: formData.workplace})
    });
    navigate("/board/create")
  }
  useEffect(() => {
    const isUserNew = async () => {
      const userNew = await getData(`${API_URL}User/user-is-new`, {
        method: "GET",
        credentials: "include"
      });
      if (!userNew) navigate("/board");
    };
    isUserNew();
  }, [navigate]);

  return (
    <main className="new-user-wrapper">
      {React.cloneElement(steps[step], { formData, setFormData })}

      <div className="btn-continue-container">
        {step < steps.length - 1 && (
          <Button onClick={next}>Siguiente</Button>
        )}
        {step == 2 && (
          <Button onClick={handleSendForm}>Empezar</Button>
        )}
      </div>
    </main>
  );
}

export default NewUser;
