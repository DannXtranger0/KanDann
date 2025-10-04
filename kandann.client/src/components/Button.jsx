import "../styles/components/Button.css";
function Button({ 
    children,
    onClick,
    icon = null,
    type="button" }) {

    return (
        <button type={type}
            className="custom-button"
            onClick={onClick}
            >
            {icon && <img src={icon}/>}
            {children}
        </button>
    );
}
export default Button;