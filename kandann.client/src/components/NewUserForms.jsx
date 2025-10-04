import "../styles/components/NewUserForm.css"

export function Step1(){
    return(
        <div className="new-user-form-container">
                <h3>Es tu primera vez aqui, empecemos rapido</h3>
        </div>
    );
}
export function Step2({formData, setFormData}){
     return(
        <div className="new-user-form-container">

            <h3>Ingresa el nombre de tu primer espacio de trabajo</h3>
            <input type="text" value={formData.workplace} onChange={(e)=>setFormData({...formData, workplace: e.target.value})} />
            <p> Tranquilo, puedes crear tantos como desees,
                piensa en ellos como una categorización de tus proyectos como:
                mi trabajos, metas personales, mis materias de la escuela ... etc.</p>
        </div>
       );
}

export function Step3({formData, setFormData}){
     return(
        <div className="new-user-form-container">
            <h3>Todo listo, ahora disfruta de la plataforma!</h3>
        </div>
       );
}


    