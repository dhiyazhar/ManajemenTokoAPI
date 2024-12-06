#!/bin/bash
set -e

until dotnet ef database update; do
  >&2 echo "Menunggu database siap untuk migrations..."
  sleep 5
done

dotnet src.dll