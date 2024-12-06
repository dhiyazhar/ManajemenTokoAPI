#!/bin/bash
set -e

export PATH="$PATH:/root/.dotnet/tools"

# Debugging path dan tools
echo "Current PATH: $PATH"
dotnet --version
dotnet-ef --version || echo "dotnet-ef tidak ditemukan"

# Tunggu database PostgreSQL siap
until pg_isready -h db -p 5432; do
  >&2 echo "Menunggu PostgreSQL siap..."
  sleep 5
done

>&2 echo "PostgreSQL siap, menjalankan migrasi database..."

# Jalankan migrasi
dotnet-ef database update

# Jalankan aplikasi utama
dotnet src.dll
