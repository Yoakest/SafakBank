"use client";

import React, { useState } from "react";
import axios from "axios";
import Link from "next/link";

export default function Register() {
  const [formData, setFormData] = useState({
    firstName: "qwe",
    lastName: "qwe",
    email: "qwe@qwe.qwe",
    password: "eqe12e12e12d",
    day: "1",
    month: "1",
    year: "1999",
    phone: "12312312312312",
  });

  const [errors, setErrors] = useState<{
    Name?: string[];
    Surname?: string[];
    Email?: string[];
    Password?: string[];
    PhoneNumber?: string[];
    DateOfBirth?: string[];
  }>({});

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();

    // Kullanıcı modeli
    const user = {
      Name: formData.firstName,
      surname: formData.lastName,
      Email: formData.email,
      Password: formData.password,
      DateOfBirth: `${formData.year}-${formData.month.padStart(
        2,
        "0"
      )}-${formData.day.padStart(2, "0")}`,
      PhoneNumber: formData.phone,
    };

    console.log("Kullanıcı Modeli:", user);

    await axios
      .post("https://localhost:7075/api/user", user, {
        headers: {
          "Content-Type": "application/json",
        },
      })
      .then((response) => {
        console.log("Başarılı:", response.data);
        // window.location.href = "/login"; // Başarılı kayıt sonrası yönlendirme
        setErrors({}); // Hataları temizle
        return response;
      })
      .catch((error) => {
        console.log("Hata:", error);
        if (error.response.data.errors) {
          setErrors(error.response.data?.errors);
        } else if (error.response.data) {
          setErrors({});
          setErrors((prev) => ({
            ...prev,
            Email: [...(prev.Email || []), error.response.data]
          }));
        }
      });
  };

  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-8">
      <h1 className="text-3xl font-bold text-gray-800 mb-4">
        <Link href="/" className="hover:underline">
          <strong>←</strong>
        </Link>{" "}
        Kayıt Ol
      </h1>
      <form
        className="flex flex-col gap-4 w-full max-w-sm"
        onSubmit={handleSubmit}
      >
        <input
          type="text"
          name="firstName"
          placeholder="Ad"
          className={`border border-gray-300 p-3 rounded-lg ${
            errors?.Name ? "border-red-500" : ""
          }`}
          value={formData.firstName}
          onChange={handleChange}
        />
        <input
          type="text"
          name="lastName"
          placeholder="Soyad"
          className={`border border-gray-300 p-3 rounded-lg ${
            errors?.Surname ? "border-red-500" : ""
          }`}
          value={formData.lastName}
          onChange={handleChange}
        />
        <input
          // type="email"
          type="text"
          name="email"
          placeholder="E-posta"
          className={`border border-gray-300 p-3 rounded-lg ${
            errors?.Email ? "border-red-500" : ""
          }`}
          value={formData.email}
          onChange={handleChange}
        />
        <input
          type="password"
          name="password"
          placeholder="Şifre"
          className={`border border-gray-300 p-3 rounded-lg ${
            errors?.Password ? "border-red-500" : ""
          }`}
          value={formData.password}
          onChange={handleChange}
        />

        {/* Doğum Tarihi */}
        <div className="flex gap-2">
          <select
            name="day"
            className={`border border-gray-300 p-3 rounded-lg w-1/3 ${
              errors?.DateOfBirth ? "border-red-500" : ""
            }`}
            value={formData.day}
            onChange={handleChange}
          >
            <option value="">Gün</option>
            {Array.from({ length: 31 }, (_, i) => (
              <option key={i + 1} value={i + 1}>
                {i + 1}
              </option>
            ))}
          </select>
          <select
            name="month"
            className={`border border-gray-300 p-3 rounded-lg w-1/3 ${
              errors?.DateOfBirth ? "border-red-500" : ""
            }`}
            value={formData.month}
            onChange={handleChange}
          >
            <option value="">Ay</option>
            {[
              "01",
              "02",
              "03",
              "04",
              "05",
              "06",
              "07",
              "08",
              "09",
              "10",
              "11",
              "12",
            ].map((month, index) => (
              <option key={index + 1} value={index + 1}>
                {month}
              </option>
            ))}
          </select>
          <select
            name="year"
            className={`border border-gray-300 p-3 rounded-lg w-1/3 ${
              errors?.DateOfBirth ? "border-red-500" : ""
            }`}
            value={formData.year}
            onChange={handleChange}
          >
            <option value="">Yıl</option>
            {Array.from(
              { length: 130 },
              (_, i) => new Date().getFullYear() - i
            ).map((year) => (
              <option key={year} value={year}>
                {year}
              </option>
            ))}
          </select>
        </div>

        <input
          type="tel"
          name="phone"
          placeholder="Telefon Numarası"
          className={`border border-gray-300 p-3 rounded-lg ${
            errors?.PhoneNumber ? "border-red-500" : ""
          }`}
          value={formData.phone}
          onChange={handleChange}
        />
        <button
          type="submit"
          className="bg-blue-400 text-white px-6 py-3 rounded-lg shadow hover:bg-blue-700 transition"
        >
          Kayıt Ol
        </button>
        <div className="flex flex-col gap-1">
          {errors
            ? Object.entries(errors).map(([key, value]) => (
                <div
                  key={key}
                  className="block bg-red-500 text-white text-xs rounded p-1 mt-0"
                >
                  {value.map((e, index) => (
                    <p key={index}>
                      {key}: {e}
                    </p>
                  ))}
                </div>
              ))
            : null}
        </div>
      </form>
    </div>
  );
}
