import "../styles/components/Button.css";
function Button({ 
    children,
    onClick,
    icon = null,
    size = "md", // "sm" | "md" | "lg"
    type="button" }) {

    return (
        <button type={type}
            className={`custom-button ${icon ? "icon" : ""}  ${size}`}
            onClick={onClick}
            >
            {icon && <img src={icon}/>}
            {children}
        </button>
    );
}
export default Button;