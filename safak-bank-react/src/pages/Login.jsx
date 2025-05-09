import React, { useState } from "react";
import axios from "axios";

export default function Login() {

    const [formData, setFormData] = useState({
        email: "qwe@qwe.qwe",
        password: "qwe123qwe123"
    });

    const [errors, setErrors] = useState({});

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        // Kullanıcı modeli
        const user = {
            Email: formData.email,
            Password: formData.password,
        };

        console.log("Kullanıcı Modeli:", user);
        await axios
            .post("https://localhost:7075/api/user/login", user, {
                headers: {
                    "Content-Type": "application/json",
                },
            })
            .then((response) => {
                console.log("Başarılı giriş:", response.data);
            })
            .catch((error) => {
                console.error("Giriş hatası:", error.response.data);
                setErrors(error.response.data.errors);
            });
    };

    return (
        <div className="flex flex-col items-center justify-center min-h-screen">
            <h1 className="text-3xl font-bold text-gray-800 mb-4">
                <a href="/" className="hover:underline">
                    <strong>←</strong>
                </a>{" "}
                Giriş Yap</h1>
            <form className="flex flex-col gap-4 w-full max-w-sm">
                <input
                    type="email"
                    placeholder="E-posta"
                    className="border border-gray-300 p-3 rounded-lg"
                    onSubmit={handleSubmit}
                    onChange={handleChange}
                    name="email"
                    value={formData.email}
                />
                <input
                    type="password"
                    placeholder="Şifre"
                    className="border border-gray-300 p-3 rounded-lg"
                    onChange={handleChange}
                    onSubmit={handleSubmit}
                    name="password"
                    value={formData.password}
                />
                <button
                    type="submit"
                    className="bg-blue-600 text-white px-6 py-3 rounded-lg shadow hover:bg-blue-700 transition"
                    onClick={handleSubmit}
                >
                    Giriş Yap
                </button>
                <p className="text-sm text-gray-600 mt-4">
                    Hesabınız yok mu?{" "}
                    <a href="/register" className="text-blue-600 hover:underline">
                        Kayıt Ol
                    </a>
                </p>
                <div className="flex flex-col gap-0.5">
                    {errors?.Email && (
                        <div className="block bg-red-500 text-white text-xs rounded p-1 mt-0">
                            {errors.Email.map((error, index) => (
                                <p key={index}>{error}</p>
                            ))}
                        </div>
                    )}
                    {errors?.Password && (
                        <div className="block bg-red-500 text-white text-xs rounded p-1 mt-0">
                            {errors.Password.map((error, index) => (
                                <p key={index}>{error}</p>
                            ))}
                        </div>
                    )}
                </div>  
            </form>
        </div>
    );
}