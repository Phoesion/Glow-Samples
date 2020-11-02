# Set Phoesion Glow Firefly image as base
FROM phoesion/phoesion.glow.firefly:latest

# Create configs dir
RUN mkdir -p /etc/phoesion/glow/firefly

# COPY configs.json to etc
COPY ./configs.json /etc/phoesion/glow/firefly/configs.json