import { useEffect } from "react";

export function useMenuToggle(ref,handler){
    useEffect(()=>{
        function listener(e){
            if(!ref.current || ref.current.contains(e.target)) return;

            handler();
        }

        //se activan listeners para cuando de click en algo, se ejecute la función listener
        //yy ahí verifico si se dió click en el menu o no para cerrar, ya que abro en el mismo menu en el layout
        document.addEventListener("mousedown",listener);
        document.addEventListener("touchstart",listener);

        // Cleanup: se ejecuta cuando el componente se desmonta
    return () => {
      document.removeEventListener("mousedown", listener);
      document.removeEventListener("touchstart", listener);
    };
    },[ref,handler])
}