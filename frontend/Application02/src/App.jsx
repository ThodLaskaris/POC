import { useSensorData } from './hooks/use'
import './App.css'

function App() {
  const { rows, loading, error} = useSensorData();
  const columns = rows.length > 0 ? Object.keys(rows[0]) : [];

  return (
    <div className='app'>
      {loading ? (
        <span>Loading..</span>
      ): error ? (
        <span>Error: {error}</span>
      ) : (
        <>
        <table className='table'>
          <thead>
            <tr>
              {columns.map((key) => (
                <th key={key}>{fixCell(key)}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.map((row, rowIndex) => (
              <tr key={rowIndex}>
                {columns.map((key) => (
                  <td key={key}>{mapCell(key, row[key])}</td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
        </>
      )}
    </div>
  )
}

  function mapCell(key, value) {
    if ( key === 'timeStamp') {
      return new Date(value).toLocaleString();
    }
    if (key === 'occupied') {
      return value ? 'True' : 'False';
    }
    return value;
  }

  function fixCell(key) {
    if (key === 'devEui') { 
      return key;
    }
    const words = key.replace(/([A-Z])/g, ' $1').split(' ');
    const formatted = words.map(x => x.charAt(0).toUpperCase() + x.slice(1));

    if (formatted.length === 2 && formatted[1].toLowerCase() === 'id'){
      formatted[1] = 'ID';
      return formatted.join(' ');
    }
    return formatted.join('');
  }
  export default App;