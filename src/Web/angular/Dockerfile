FROM node:13-alpine AS Builder

RUN npm install -g @angular/cli
ADD ./package.json /app/package.json
WORKDIR /app
RUN npm install
ADD . /app
RUN node --max_old_space_size=16384 node_modules/@angular/cli/bin/ng build --prod

FROM nginx:alpine

COPY --from=Builder /app/dist/corretora /usr/share/nginx/html
COPY ./nginx.conf /etc/nginx/conf.d/default.conf

