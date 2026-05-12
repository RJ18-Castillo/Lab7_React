import { useEffect, useState } from "react";
import "./App.css";

function App() {

    const [productos, setProductos] = useState([]);

    useEffect(() => {

        fetch("https://localhost:7174/api/ProductsApi")
            .then(response => response.json())
            .then(data => setProductos(data))
            .catch(error => console.error(error));

    }, []);

    return (
        <div className="container">

            <h1>Inventario</h1>

            <table>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Categoría</th>
                        <th>Precio</th>
                        <th>Stock</th>
                    </tr>
                </thead>

                <tbody>
                    {productos.map(producto => (
                        <tr key={producto.id}>
                            <td>{producto.id}</td>
                            <td>{producto.nombre}</td>
                            <td>{producto.categoria}</td>
                            <td>{producto.precio}</td>
                            <td>{producto.stock}</td>
                        </tr>
                    ))}
                </tbody>

            </table>

        </div>
    );
}

export default App;