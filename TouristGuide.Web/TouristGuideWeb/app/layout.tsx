import 'react-perfect-scrollbar/dist/css/styles.css'
import "/public/assets/css/style.css"
import type { Metadata } from "next"
import { Manrope, Merienda } from "next/font/google"

const manrope = Manrope({
    weight: ['300', '400', '500', '600', '700','800'],
    subsets: ['latin'],
    variable: "--manrope",
    display: 'swap',
})
const merienda = Merienda({
    weight: ['300', '400', '500', '600', '700','800'],
    subsets: ['latin'],
    variable: "--merienda",
    display: 'swap',
})

export const metadata: Metadata = {
    title: "",
    description: "",
}

export default function RootLayout({
    children,
}: Readonly<{
    children: React.ReactNode
}>) {
    return (
        <html lang="en" className={`${manrope.variable}, ${merienda.variable}`}>
            <body>{children}</body>
        </html>
    )
}
