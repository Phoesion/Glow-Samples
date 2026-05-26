CALL docker run --rm -p 80:80 -p 443:443 -p 15000:15000 -it packaged_hologram

# CALL docker run --rm -p 80:80 -p 443:443 -p 15000:15000 -it -v ./MyServices.pghologram:/app/services.pghologram packaged_hologram