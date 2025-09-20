import "../styles/components/CustomButton.css";
function CustomButton({ children, onClick, style }) {

    return (
        <button className="custom-button" onClick={onClick} style={style} >
            {children}
        </button>
    );
}
export default CustomButton;