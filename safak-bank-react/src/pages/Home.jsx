function Home() {
    return (
        <div className="flex flex-col items-center justify-center min-h-screen ">
            {/* Logo */}
            <img
                src="/bank-logo.png"
                alt="Safak Bank Logo"
                width={120}
                height={120}
                className="mb-6"
            />

            {/* Başlık */}
            <h1 className="text-4xl font-bold text-gray-800 mb-4">Şafak Bank</h1>

            {/* Açıklama */}
            <p className="text-lg text-gray-600 text-center mb-8">
                Güvenilir ve hızlı bankacılık deneyimi için Şafak Bank'a hoş geldiniz.
            </p>

            {/* Butonlar */}
            <div className="flex gap-4">
                <a
                    href="/login"
                    className="bg-blue-400 text-white px-6 py-3 rounded-lg shadow hover:bg-blue-700 transition"
                >
                    Giriş Yap
                </a>
                <a
                    href="/register"
                    className="bg-gray-200 text-gray-800 px-6 py-3 rounded-lg shadow hover:bg-gray-300 transition"
                >
                    Kayıt Ol
                </a>
            </div>
        </div>
    )
}

export default Home;