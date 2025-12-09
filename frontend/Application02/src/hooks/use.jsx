import { useEffect, useState } from 'react';

export function useSensorData() {
    const [rows, setRows] = useState([]);
    const [loading, setLoading] = useState();
    const [error, setError] = useState();

    useEffect(() => {
        fetch('http://localhost:5000/api/sensor-data')
        .then((response) => {
            if (!response.ok) {
                throw new Error('Fail')
            }
            return response.json();
        })
        .then((data) => {
            setRows(data);
        })
        .catch((error) => {
            setError(error.message);
        })
        .finally(() => {
            setLoading(false);
        })
    }, []);
    return { rows, loading, error};
}