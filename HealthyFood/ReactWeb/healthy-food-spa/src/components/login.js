import React, {useState, useEffect} from 'react';
import { loginApi } from '../services/loginApi'

function Login() {
    const [isLoggedIn, setIsLoggedIn] = useState(!!(localStorage.getItem("userId")))
    const [name, setName] = useState()
    const [userId, setUserId] = useState(0)
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const {GetUserId, GetUser} = loginApi;

    useEffect(()=>{
        GetUser(userId).then(response => setName(response.data.name))
    }, [userId])

    const SubmitHandler=(e)=>{
        e.preventDefault();
        GetUserId(login, password).then(response => {
            setUserId(response.data)
            localStorage.setItem("userId", userId)
            setIsLoggedIn(true)
        });
    }

    function LogoutHandler(){
        localStorage.removeItem("userId")
        setIsLoggedIn(false)
    }

    return (
        <> 
        { isLoggedIn ? 
            (
                <div>
                    <div>UserName: {name}</div>
                    <button onClick={LogoutHandler}>LogOut</button>
                </div>
            ) :
            
            (
                <form onSubmit={SubmitHandler}>
                    <div>
                        <p>Login:</p>
                        <input type='text' value={login} onChange={e => setLogin(e.target.value)}></input>
                    </div>
                    <div>
                        <p>password</p>
                        <input type='password' value={password} onChange={e => setPassword(e.target.value)}></input>
                    </div>
                    <button type='submit'>Submit</button>
                </form>) }
        </>
    )
}

export default Login;