import { useState } from "react";
import "./App.css";

function App() {
    const [form, setForm] = useState({
        amount: "",
        department: "Technology",
        employeeSeniority: 0.1,
        purchaseType: "Software",
        availableBudget: ""
    });

    const [result, setResult] = useState(null);

    const handleChange = (e) => {
        const { name, value } = e.target;

        setForm((previous) => ({
            ...previous,
            [name]: value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch(
                "/PurchaseRequest",
                {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify({
                        amount: Number(form.amount),
                        department: form.department,
                        employeeSeniority: Number(form.employeeSeniority),
                        purchaseType: form.purchaseType,
                        availableBudget: Number(form.availableBudget)
                    })
                }
            );

            const data = await response.json();

            if (!response.ok) {

                if (response.status === 400) {
                    const errors = Object.values(data.errors)
                        .flat();

                    setResult({
                        status: "Error",
                        reason: errors.join(", ")
                    });
                }
                else {
                    setResult({
                        status: "Error",
                        reason: "Ocurrió un error inesperado en el servidor."
                    });
                }

                return;
            }


            setResult(data);

        } catch (error) {

            setResult({
                status: "Error",
                reason: "No se pudo conectar con el servidor."
            });

            console.error(error);
        }
    };

    return (
        <div className="container">
            <div className="card">
                <h3>Purchase Approval System</h3>

                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label>Amount</label>
                        <input
                            type="number"
                            name="amount"
                            value={form.amount}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Department</label>

                        <select
                            name="department"
                            value={form.department}
                            onChange={handleChange}
                        >
                            <option value="Technology">Technology</option>
                            <option value="Finance">Finance</option>
                            <option value="HumanResources">Human Resources</option>
                            <option value="HumanResources">Sales</option>
                        </select>
                    </div>

                    <div className="form-group">
                        <label>Employee Seniority</label>

                        <input
                            type="number"
                            name="employeeSeniority"
                            value={form.employeeSeniority}
                            onChange={handleChange}
                        />
                    </div>

                    <div className="form-group">
                        <label>Purchase Type</label>

                        <select
                            name="purchaseType"
                            value={form.purchaseType}
                            onChange={handleChange}
                        >
                            <option value="Software">Software</option>
                            <option value="Equipment">Equipment</option>
                            <option value="Services">Furniture</option>
                            <option value="Services">Services</option>
                        </select>
                    </div>

                    <div className="form-group">
                        <label>Available Budget</label>

                        <input
                            type="number"
                            name="availableBudget"
                            value={form.availableBudget}
                            onChange={handleChange}
                        />
                    </div>

                    <button className="submit-btn" type="submit">
                        Evaluate Request
                    </button>
                </form>

                {result && (
                    <div className={`result ${result.status.toLowerCase()}`}>
                        <h2>{result.status}</h2>
                        <p>{result.reason}</p>
                    </div>
                )}
            </div>
        </div>
    );
}

export default App;