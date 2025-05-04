import Link from "next/link";

export default function Login() {
  return (
    <div className="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-8">
      <h1 className="text-3xl font-bold text-gray-800 mb-4">
      <Link href="/" className="hover:underline">
          <strong>←</strong>
        </Link>{" "}
        Giriş Yap</h1>
      <form className="flex flex-col gap-4 w-full max-w-sm">
        <input
          type="email"
          placeholder="E-posta"
          className="border border-gray-300 p-3 rounded-lg"
        />
        <input
          type="password"
          placeholder="Şifre"
          className="border border-gray-300 p-3 rounded-lg"
        />
        <button
          type="submit"
          className="bg-blue-600 text-white px-6 py-3 rounded-lg shadow hover:bg-blue-700 transition"
        >
          Giriş Yap
        </button>
      </form>
    </div>
  );
}