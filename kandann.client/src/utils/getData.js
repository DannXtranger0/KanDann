export async function getData(url, options = {}) {
    try{
        let response = await fetch(url, options);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        let data = await response.json();
        console.log(data);
        return data;
    }catch(e){
        console.error("Error fetching data:", e);
    }
}