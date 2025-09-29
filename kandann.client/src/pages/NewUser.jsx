import { useEffect, useState } from "react";
import React from "react";
import { getData } from "../utils/getData";
import { useNavigate } from "react-router-dom";
import "../styles/NewUser.css";
import { Step1, Step2, Step3 } from "../components/NewUserForms";
import CustomButton from "../components/CustomButton";

const API_URL = import.meta.env.VITE_API_URL;

const steps = [<Step1 />, <Step2 />, <Step3 />];

function NewUser() {
  const navigate = useNavigate();
  const [step, setStep] = useState(0);
  const [formData, setFormData] = useState({
    workplace: "",
    board: ""
  });

  const next = () => setStep(s => s + 1);

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
          <CustomButton onClick={next}>Siguiente</CustomButton>
        )}
        {step == 2 && (
          <CustomButton onClick={next}>Empezar</CustomButton>
        )}
      </div>
    </main>
  );
}

export default NewUser;
