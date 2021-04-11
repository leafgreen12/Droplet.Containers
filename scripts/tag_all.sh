#!/usr/bin/env bash


docker tag ${REGISTRY:-Droplet}/dynamic.api:${PLATFORM:-linux}-${TAG:-latest}
docker tag ${REGISTRY:-Droplet}/emailing.api:${PLATFORM:-linux}-${TAG:-latest}
docker tag ${REGISTRY:-Droplet}/identity.api:${PLATFORM:-linux}-${TAG:-latest}
docker tag ${REGISTRY:-Droplet}/settings.api:${PLATFORM:-linux}-${TAG:-latest}
docker tag ${REGISTRY:-Droplet}/storage.api:${PLATFORM:-linux}-${TAG:-latest}
docker tag ${REGISTRY:-Droplet}/webhooks.api:${PLATFORM:-linux}-${TAG:-latest}